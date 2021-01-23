    using System.ComponentModel;
    using System.Dynamic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    namespace WpfApplication1.Properties
    {
        /// <summary>
        /// Proxy to envelop a resx class and attach INotifyPropertyChanged behavior to it.
        /// Enables runtime change of language through the ChangeCulture method.
        /// </summary>
        public class ResourcesProxy : DynamicObject, INotifyPropertyChanged
        {
            private Resources _proxiedResources = new Resources(); // proxied resx
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(_proxiedResources, new PropertyChangedEventArgs(propertyName));
            }
            /// <summary>
            /// Sets the new culture on the resources and updates the UI
            /// </summary>
            public void ChangeCulture(CultureInfo newCulture)
            {
                Resources.Culture = newCulture;
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(null));
            }
            private PropertyInfo GetPropertyInfo(string propertyName)
            {
                return _proxiedResources.GetType().GetProperties().First(pi => pi.Name == propertyName);
            }
            private void SetMember(string propertyName, object value)
            {
                GetPropertyInfo(propertyName).SetValue(_proxiedResources, value, null);
                OnPropertyChanged(propertyName);
            }
            private object GetMember(string propertyName)
            {
                return GetPropertyInfo(propertyName).GetValue(_proxiedResources, null);
            }
            public override bool TryConvert(ConvertBinder binder, out object result)
            {
                if (binder.Type == typeof(INotifyPropertyChanged))
                {
                    result = this;
                    return true;
                }
                if (_proxiedResources != null && binder.Type.IsAssignableFrom(_proxiedResources.GetType()))
                {
                    result = _proxiedResources;
                    return true;
                }
                else
                    return base.TryConvert(binder, out result);
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = GetMember(binder.Name);
                return true;
            }
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                SetMember(binder.Name, value);
                return true;
            }
        }
    }
