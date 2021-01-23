    //declared this 2 classes at the top
    class Options {
        public string icon {
            get;
            set;
        }
    }
    class Aux {
        public string lat {
            get;
            set;
        }
        public string lng {
            get;
            set;
        }
        public string data {
            get;
            set;
        }
        public Options options {
            get;
            set;
        }
    }
    private void SetMap () {
        Options opt = new Options();
        List<Aux> aux = new List<Aux>();
        //this is to make the code to work with dinamic content
        string[] latitude = new string[3];
        string[] longitude = new string[3];
        string[] designacao = new string[3];
        latitude[0] = "38.713852";
        latitude[1] = "39.825751";
        latitude[2] = "38.730638";
        longitude[0] = "-9.145621";
        longitude[1] = "-7.479642";
        longitude[2] = "-9.139604";
        designacao[0] = "Loja centro de Braga";
        designacao[1] = "Apartamento T3";
        designacao[2] = "sxpto";
        for (int i=0; i< 3; i++){
            opt.icon = "../layout/icon_map_point.png";
            //this is what it's really needed
            aux.Add(new Aux {lat = latitude[i], lng = longitude[i], data = "div align=left class=gmapsoverlay><span>"+designacao[i]+"</span></div>", options = opt});
        }
        // end of dinamic content
        if(aux != null) {
            //parse the whole object to JSON
            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = jsonSerializer.Serialize(aux);
            hdd_GmapPoints.Value = json;
        }
    }
