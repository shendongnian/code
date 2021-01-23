    foreach(var a in profileModel.Resources)
                {
                    a.Business = null;
                    a.Access.Resource = null;
                    a.Goal.Resource = null;
                    a.Setting.Resource = null;
                    
                }
    
                profileModel.Mission.Business=null; 
