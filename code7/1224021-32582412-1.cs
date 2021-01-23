        public class Groups // "Groups": [
        {
            public int UniqueId { get; set; } // "UniqueId": "1",
            public String Name { get; set; } //  "Name": "England",
            public List<Member> ListMembers { get; set; } // "Members": [
            public Groups(string json)
            {
                /* use your json object to get different data */
                UniqueId = "Group UniqueId";
                Name = "Group Name";
                
                // get all member
                foreach (jsonMember in jsonObject.Members)
                {
                    Member member = new Member
                    {
                        UniqueId = "jsonMember UniqueId",
                        Name = "jsonMember Name",
                        JerseyNumber = "jsonMember JerseyNumber",
                        Position = "jsonMember Position",
                    };
                    ListMembers.Add(member);
                }
            }
            public class Member // {"UniqueId":"Nani", "Name":"Nani", ... }
            {
                public string UniqueId { get; set; } // "UniqueId": "Aquero",
                public String Name { get; set; } // "Name": "Aguero",
                public int JerseyNumber { get; set; } // "JerseyNumber": "16",
                public string Position { get; set; } // "Position": "Forward"
            }
            public void Delete(string UniqueId) // by example Delete("Nani")
            {
                ListMembers.RemoveAll(m => m.UniqueId == UniqueId);
            }
        }
