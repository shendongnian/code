     [DataContract]
        public class Pers_Ordre_NET
        {
            [DataMember(Name = "CodeClient")]
            string _CodeClient;
            public string CodeClient
            {
                get { return _CodeClient; }
                set { _CodeClient = value; }
            }
    
           [DataMember(Name = "CodeDest")]
            string _CodeDest;
            public string CodeDest
            {
                get { return _CodeDest; }
                set { _CodeDest = value; }
            }
    
            [DataMember(Name = "NoOrdre")]
            string _NoOrdre;
            public string NoOrdre
            {
                get { return _NoOrdre; }
                set { _NoOrdre = value; }
            }
    
            [DataMember(Name = "LeDate")]
            string _LeDate;
            public string LeDate
            {
                get { return _LeDate; }
                set { _LeDate = value; }
            }
    
            [DataMember(Name = "LeGPS")]
            string _LeGPS;
            public string LeGPS
            {
                get { return _LeGPS; }
                set { _LeGPS = value; }
            }
    
            [DataMember(Name = "LeStatut")]
            string _LeStatut;
            public string LeStatut
            {
                get { return _LeStatut; }
                set { _LeStatut = value; }
            }
    
            [DataMember(Name = "LeCamion")]
            string _LeCamion;
            public string LeCamion
            {
                get { return _LeCamion; }
                set { _LeCamion = value; }
            }
