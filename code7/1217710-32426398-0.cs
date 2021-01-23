        [Serializable]
        [DataContract]
        public class WorkflowParameter
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public string Value { get; set; }
        }
        [Serializable]
        [DataContract]
        public class WorkflowStartParameters
        {
            [DataMember]
            public WorkflowParameter[] ProcessParameters { get; set; }
            [DataMember]
            public string Process { get; set; }
        }
