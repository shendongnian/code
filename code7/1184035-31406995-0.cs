       [DataContract]
       [Guid("xxx")]
       [StructLayout(LayoutKind.Sequential), Serializable]
       [ComVisible(true)]
       public struct MyData
       {
          [DataMember]
          public int data1;
    
          [DataMember]
          [MarshalAs(UnmanagedType.BStr)]
          public string data2;
       }
