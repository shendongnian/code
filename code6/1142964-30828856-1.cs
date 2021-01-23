    [Queryable]//enable the $select,$expend Queries
    [HttpPost]//All the action methods are of post type in Web api
    public IQueryable<FooBarBaz> Distinct(ODataActionParameters parameters)
    {
            string on = "";
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
    
            try
            {
                 on = parameters["On"] as string;
            }
            catch (NullReferenceException ex)
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                message.Content = new StringContent("{\"Error\":\"Invalid Query -> On property is not defined\"}");
                throw new HttpResponseException(message);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            PropertyInfo[] props = new FooBarBaz().GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var isPropertyExist = false;
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].Name.Equals(on))
                {
                    isPropertyExist = true;
                    break;
                }
            }
    
    
            if (isPropertyExist)
            {
                var fooBarBazCollection = db.fooBarBazs.GroupBy(GetGroupKey(on)).Select(g => g.FirstOrDefault());//Select the Distinct Entity on the basis of a property
                return fooBarBazCollection ;
            }
            else
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.BadRequest);
                message.Content = new StringContent("{\"Error\":\"Property '"+on+"' Not Exist}");
                throw new HttpResponseException(message);
            }
    }
