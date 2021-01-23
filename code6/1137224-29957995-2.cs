    namespace Steap
    {
        public class SteapAPI
        {
            public String URL
            {
                get;
                set;
            }
    
            public XmlReader r;
    
            public SteapAPI(string url)
            {
                URL = url;
                //NOTE: This is wrong! You can't create an XmlReader with a URL
                //and expect it to fetch a web resource.
                r = XmlReader.Create(URL + "?xml=1&l=english");
            }
    
            public int getSteamID64()
            {
                int ID = 0;
                r.ReadToFollowing("steamID64");
                ID = r.ReadContentAsInt();
                return ID;
            }
    
            public string getSteamID()
            {
                string ID = String.Empty;
                r.ReadToFollowing("steamID");
                ID = r.ReadContentAsString();
                return ID;
            }
    
            public int getVac()
            {
                int Vac = 0;
                r.ReadToFollowing("vacBanned");
                Vac = r.ReadContentAsInt();
                return Vac;
            }
    
            public bool hasVac()
            {
                if (getVac() == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
    
    
            // =================== [ Aliases
    
            public string getName()
            {
                return getSteamID();
            }
        }
