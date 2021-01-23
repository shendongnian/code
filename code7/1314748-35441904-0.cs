    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
        
    namespace Test {
        public class WareHouse {
        private Dictionary<string, int> wareHouseRepo = new Dictionary<string, int>();
        
        public void Add(string location, int number) {
        //null add
        if (wareHouseRepo.ContainsKey(location)) {
        int inventory_Old = wareHouseRepo[location];
            wareHouseRepo[location] = inventory_Old + number;
        } else {
             wareHouseRepo.Add(location, number);
        }
    }
        
        
    public virtual bool FillIt(string location, int number) {
        if (wareHouseRepo.ContainsKey(location)) {
            int inventory = wareHouseRepo[location];
            if(inventory >= number){
                wareHouseRepo[location] = inventory - number;
                return true;
            }else{
                return false;
            }
        } else {
            return false;
        }
    }
    }    
        
    public int GetInventory(string location) {
        if (wareHouseRepo.ContainsKey(location)) {
            return wareHouseRepo[location];              
        } else {
            return 0;
        }
        }
    }
        
