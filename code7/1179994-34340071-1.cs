        [DataContract]
        public class ResultOfMyDtos : BaseClass<MyDto>
        {
            [DataMember(Order = 1)]
            public new bool IsOk
            {
                get { return base.IsOk; }
                set { base.IsOk = value; }
            }
    
            [DataMember(Order = 2)]
            public new List<MyDto> Results
            {
                get { return base.Results; }
                set { base.Results = value; }
            }
    
            [DataMember(Order = 3)]
            public string Validation { get; set; }
        }
