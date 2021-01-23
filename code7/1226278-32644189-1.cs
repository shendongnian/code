    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace System
    {
        /// <summary>
        /// class which implements INotifyPropertyChanged in such manner that event can be broadcasted in safe manner - 
        /// even if given item is removed from BindingList, event in BindingList (Child_PropertyChanged) won't be 
        /// triggered.
        /// </summary>
        public class MulticastNotifyPropertyChanged : INotifyPropertyChanged
        {
            /// <summary>
            /// List of all registered events. List can change during event broadcasting.
            /// </summary>
            List<PropertyChangedEventHandler> _PropertyChangedHandlers = new List<PropertyChangedEventHandler>();
            /// <summary>
            /// Next broadcasted event index.
            /// </summary>
            int iFuncToInvoke;
        #if TESTINVOKE
                PropertyChangedEventHandler _PropertyChangedAllInOne;
        #endif
            event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
            {
                add
                {
        #if TESTINVOKE
                        _PropertyChangedAllInOne += value;
        #endif
                    _PropertyChangedHandlers.Add(value);
                }
                remove
                {
        #if TESTINVOKE
                        _PropertyChangedAllInOne -= value;
        #endif
                    int index = _PropertyChangedHandlers.IndexOf(value);
                    if (index == -1)
                        return;
                    if (iFuncToInvoke >= index)     //Scroll back event iterator if needed.
                        iFuncToInvoke--;
        #if TESTINVOKE
                        Console.WriteLine("Unregistering event. Iterator value: " + iFuncToInvoke.ToString());
        #endif
                    _PropertyChangedHandlers.Remove(value);
                }
            }
            /// <summary>
            /// Just an accessor, so no cast would be required on client side.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged
            {
                add
                {
                    ((INotifyPropertyChanged)this).PropertyChanged += value;
                }
                remove
                {
                    ((INotifyPropertyChanged)this).PropertyChanged -= value;
                }
            }
            /// <summary>
            /// Same as normal Invoke, except this plays out safe - if item is removed from BindingList during event broadcast -
            /// event won't be fired in removed item direction.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void Invoke(object sender, PropertyChangedEventArgs e)
            {
                for (iFuncToInvoke = 0; iFuncToInvoke < _PropertyChangedHandlers.Count; iFuncToInvoke++)
                {
        #if TESTINVOKE
                        Console.WriteLine("Invoke: " + iFuncToInvoke.ToString());
        #endif
                    _PropertyChangedHandlers[iFuncToInvoke].Invoke(sender, e);
                }
            }
        #if TESTINVOKE
                public void InvokeFast( object sender, PropertyChangedEventArgs e )
                {
                    _PropertyChangedAllInOne.Invoke(sender, e);
                }
        #endif
        }
    } //namespace System
