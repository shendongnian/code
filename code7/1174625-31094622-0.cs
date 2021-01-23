    public void FirstInsert(){
        using (var cn = new Connection().GetConnection()){
            cn.Open();
            using (var tran = cn.BeginTransaction()){
                try{
                    //1st insert
                    SecondInsert() //calling second insert method
                    tran.Commit();                
                }
                catch{
                    tran.Rollback();
                }
            }
        }
    }
    
    public void SecondInsert(){
    
                   //perform second insert operation             
            }
        }
    }
