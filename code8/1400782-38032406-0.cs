    [DataContract]
    class CommunicationMessage
    {
        [DataContract]
        class SkillsData
        {
            [DataContract]
            internal class SkillData
            {
                [DataMember(Name = "SkillID")]
                internal object SkillID;
                [DataMember(Name = "ParticipantID")]
                internal object ParticipantID;
                [DataMember(Name = "CanDo")]
                internal object CanDo;
            }
            [DataMember(Name = "Skill")]
            internal SkillData[] Skill;
        }
        [DataMember(Name = "Skills")]
        SkillsData[] Skills;
    }
