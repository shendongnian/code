    public ActionResult GetKey(Guid id)  
    {
                var vm = new vmGetKey();
        
                vm.Guid = id;
                
                //create a purpose
                var purpose = new string[] { "Test", "WithAPurpose" };
        
                //encrypt  key1
                vm.key1 = Key.EncryptWithAPurpose(id.ToString(),  purpose);
        
                //encrypt Key2
                vm.key2 = Key.EncryptWithAPurpose(id.ToString(), purpose);
        
                //decrypt key1
                vm.key1_DecryptResult = Key.DecryptWithAPurpose(vm.key1, purpose);
                
                //decrypt key2
                vm.key2_DecryptResult = Key.DecryptWithAPurpose(vm.key2, purpose);
        
                return View(vm);
    }
        
    public class vmGetKey
    {
        public Guid Guid { get; set; }
        public string key1 { get; set; }
        public string key2 { get; set; }
        public string key1_DecryptResult { get; set; }
        public string key2_DecryptResult { get; set; }        
    }        
        }
