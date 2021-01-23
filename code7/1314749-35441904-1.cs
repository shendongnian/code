    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
        
        namespace Test {
            class Order {
                private string location = "";
                private int orderNum = 0;
        
                private bool filled = true;
        
                public Order(string loc, int num) {
                    this.location = loc;
                    this.orderNum = num;
                }
        
                public void Fill(WareHouse wh){
                    if (wh.FillIt(location, orderNum)) {
                        filled = true;
                    } else {
                        filled = false;
                    }
                }
        
                public bool isFilled() {
                    return filled;
                }
        
            }
        }
