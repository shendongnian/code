        public T this[int index] {
    #if !FEATURE_CORECLR
            [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    #endif
            get { return items[index]; }
            set {
                if( items.IsReadOnly) {
                    ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
                }
                
                if (index < 0 || index >= items.Count) {
                    ThrowHelper.ThrowArgumentOutOfRangeException();
                }
 
                SetItem(index, value);
            }
        }
