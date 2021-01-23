      List<dynamic> dynList = new List<dynamic>();
                for (int i = 0; i < d.Count; i++)
                {
                    dynamic dynObj = new ExpandoObject();
                    ((IDictionary<string, object>)dynObj).Add("FileTypeCode", result[i].FileTypeCode.ToString());
                    ((IDictionary<string, object>)dynObj).Add("Fullname", result[i].Fullname.ToString());
                    ((IDictionary<string, object>)dynObj).Add("Entitlement", result[i].Entitlement.ToString());
    
                    var res = d[i].ColumnName.ToList();
                    for (int j = 0; j < res.Count; j++)
                    {
                        ((IDictionary<string, object>)dynObj).Add(res[j].Col.ToString(), res[j].Value.ToString());
                    }
    
                    dynList.Add(dynObj);
                }
                var dList = (from da in dynList select da).ToList();
    
                return dList;
