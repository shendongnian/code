    public class PersonData
    {
       public string name { get; set; }
       public string phone { get; set; }
       public string sex { get; set; }
    }
        
    [HttpPost]
    public string PostData([FromBody]PersonData form)
    {
       string name=form.name;
       string phone=form.phone
       string sex=form.sex;
    }
