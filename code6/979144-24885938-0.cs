      string Service = "http://localhost:58092/Service1.svc/DataService/LoadAllData";
                    WebRequest wreq = WebRequest.Create(Service);
                    WebResponse wres = wreq.GetResponse();
    
                    DataContractSerializer coll = new DataContractSerializer(typeof(IList<DataServiceProxy.Product>));
                    //   MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(coll.));
    
                    var arrProd = coll.ReadObject(wres.GetResponseStream());
    
                    DataServiceProxy.Product[] prd = arrProd as DataServiceProxy.Product[];
                    lstProd = new List<DataServiceProxy.Product>(prd);
