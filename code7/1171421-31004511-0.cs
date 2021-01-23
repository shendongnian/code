    namespace MyNameSpace
    {
        public class Info 
        {
            // When newtonsoft serialize a property of this type (CDataField) 
            // a get an empty string as value.
            public string Name { get; set; }
            public string Email { get; set; }
            public string IdNNumber {get; set;}
            Info(ThirdiParty.Lib.Info info)
            {
                Name = info.Name.ToString();
                Email = info.Email.ToString();
                IdNumber = info.IdNumber;
            }
        }
     }
        
    var myinfo = new MyNameSpace.Info(
        new ThirdiParty.Lib.Info()
        {
            IdNumber = "001254810",
            Name = "John Doe",
            Email = "johndoe@gmail.com"
        }
    );
