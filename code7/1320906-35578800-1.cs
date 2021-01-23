    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"LearnerTelephones\":{ \"ID\": \"eaf32af9-07bf-4d87-8aeb-84ac8860dee9\", \"IsFirstPointOfContact\": true, \"LocationType\": { \"ID\": \"ebbbaa62-f1f0-4010-8b0b-ee744eafc1de\", \"NameType\":[{ \"IDNAME\": \"my name\", \"IDAdd\": \"my id address\" }, { \"IDNAME\": \"my name2\", \"IDAdd\": \"my id address2\" } ] }, \"Notes\": null, \"TelephoneNumber\": \"028 3282 3717\", \"UseForTextMessages\": true } }";
            RootObject obj = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json);
            string sql = string.Empty;
            if (obj != null)
            {
                for (int i = 0; i < obj.LearnerTelephones.LocationType.NameType.Count; i++)
                {
                    var obj1 = obj.LearnerTelephones;
                    sql += string.Format("insert into table1(LearnerTelephones_ID,LearnerTelephones_IsFirst,LearnerTelephones_L_ID , LearnerTelephones_Ln_IDNAME, LearnerTelephones_Ln_IDAdd,LearnerTelephones_Notes,LearnerTelephones_TelephoneNumber,LearnerTelephones_UseForText) values " +
                                              "('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", obj1.ID, obj1.IsFirstPointOfContact, obj1.LocationType.NameType[i].IDNAME, obj1.LocationType.NameType[i].IDAdd, obj1.Notes, obj1.TelephoneNumber, obj1.UseForTextMessages);
                }
            }
            Console.WriteLine(sql);
            Console.Read();
        }
    }
