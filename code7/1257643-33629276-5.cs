    query.ForEach(
          item =>
          {   
              item.ExtraData=new ExtraData();    
              item.ExtraData.DataID = item.Data.ID;
              item.ExtraData.Name = item.Data.NameAux; 
              item.ExtraData.Group = elem.Data.ExtraGroup;       
          }
          );
