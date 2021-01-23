            List<Envolvido> mylist = t.Result;
             for (int index = 0; index < mylist.Count(); index++)
             {
                 var items = mylist.ToList();
                 Envolvido envolvido = items[index];
                 envolvido.SUSPID= Convert.FromBase64String(envolvido.SUSPID);
                 envolvido.IVNOME = Convert.FromBase64String(envolvido.IVNOME);
              }
