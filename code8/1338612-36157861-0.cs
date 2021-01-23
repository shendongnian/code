    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    public class PropertyErrors : INotifyDataErrorInfo
    {
        private static readonly IReadOnlyList<object> EmptyErrors = new object[0];
        private readonly Action<DataErrorsChangedEventArgs> ownerOnErrorsChanged;
        private readonly Type type;
        private readonly ConcurrentDictionary<string, List<object>> propertyErrors = new ConcurrentDictionary<string, List<object>>();
        public PropertyErrors(INotifyDataErrorInfo owner, Action<DataErrorsChangedEventArgs> ownerOnErrorsChanged)
        {
            this.ownerOnErrorsChanged = ownerOnErrorsChanged;
            this.type = owner.GetType();
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public bool HasErrors => this.propertyErrors.Count > 0;
        public IEnumerable GetErrors(string propertyName)
        {
            Debug.Assert(this.type.GetProperty(propertyName) != null, $"The type {this.type.Name} does not have a property named {propertyName}");
            List<object> errors;
            return this.propertyErrors.TryGetValue(propertyName, out errors)
                ? errors
                : EmptyErrors;
        }
        public void Add(string propertyName, object error)
        {
            Debug.Assert(this.type.GetProperty(propertyName) != null, $"The type {this.type.Name} does not have a property named {propertyName}");
            this.propertyErrors.AddOrUpdate(
                propertyName,
                _ => new List<object> { error },
                (_, errors) => UpdateErrors(error, errors));
            this.OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
        }
        public void Remove(string propertyName, Predicate<object> filter)
        {
            Debug.Assert(this.type.GetProperty(propertyName) != null, $"The type {this.type.Name} does not have a property named {propertyName}");
            List<object> errors;
            if (this.propertyErrors.TryGetValue(propertyName, out errors))
            {
                errors.RemoveAll(filter);
                if (errors.Count == 0)
                {
                    this.Clear(propertyName);
                }
            }
        }
        public void Clear(string propertyName)
        {
            Debug.Assert(this.type.GetProperty(propertyName) != null, $"The type {this.type.Name} does not have a property named {propertyName}");
            List<object> temp;
            if (this.propertyErrors.TryRemove(propertyName, out temp))
            {
                this.OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
            }
        }
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            this.ErrorsChanged?.Invoke(this, e);
            this.ownerOnErrorsChanged(e);
        }
        private static List<object> UpdateErrors(object error, List<object> errors)
        {
            if (!errors.Contains(error))
            {
                errors.Add(error);
            }
            return errors;
        }
    }
