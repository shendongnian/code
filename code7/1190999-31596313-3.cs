    struct TVector3<T>
    {
        private T[] arr = new T[3];
    
        public T this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
    }
    struct TVector4<T>
    {
        private T[] arr = new T[4];
    
        public T this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
    }
    using TVector3i = TVector3<int>;
    using TVector3f = TVector3<float>;
    using TVector3d = TVector3<double>;
    using TVector4i = TVector4<int>;
    using TVector4f = TVector4<float>;
    using TVector4d = TVector4<double>;
    using TMatrix3i = TVector3<TVector3i>;
    using TMatrix3f = TVector3<TVector3f>;
    using TMatrix3d = TVector3<TVector3d>;
    using TMatrix4i = TVector4<TVector4i>;
    using TMatrix4f = TVector4<TVector4f>;
    using TMatrix4d = TVector4<TVector4d>;
