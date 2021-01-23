        [DataContract]
        class ObjectDataList
        {
            [DataMember(Name ="data")]
            List<ObjectData> Data;
        }
        [DataContract]
        class ObjectData
        {
            [DataMember(Name = "ID")]
            string Id;
            [DataMember(Name = "name")]
            string Name;
            [DataMember(Name = "objCode")]
            string ObjCode;
            [DataMember(Name = "percentComplete")]
            float PercentComplete;
            [DataMember(Name = "plannedCompletionDate")]
            string PlannedCompletionDate;
            [DataMember(Name = "plannedStartDate")]
            string PlannedStartDate;
            [DataMember(Name = "priority")]
            int Priority;
            [DataMember(Name = "projectedCompletionDate")]
            string projectedCompletionDate;
            [DataMember(Name = "status")]
            string Status;
        }
