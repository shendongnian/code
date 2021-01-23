     public class EntityPermission
        {
            private readonly List<GetUserPermissionsResult> _userPermissionDataSet;
            private readonly Dictionary<int, Dictionary<int, int>> _permissions;
            /// <summary>
            /// Constructor to generate permissions for a user
            /// </summary>
            /// <param name="ds">
            /// Dataset of type List GetUserPermissionsResult
            /// based on a stored procedure which brings back the 
            /// valid permissions of a user.
            /// The result is a matrix of size [Enitities] * [Actions]
            /// Where each entity action [index] is the value (right).
            /// In general terms, the entity e with action a has right r.
            /// </param>
            public EntityPermission(List<GetUserPermissionsResult> ds)
            {
                _userPermissionDataSet = ds;
                _permissions = new Dictionary<int, Dictionary<int, int>>();
                SetPermissions();
            }
    
            /// <summary>
            /// Called from the constructor of EntityPermission.
            /// This method fills our matrix of size entity * action with 
            /// the valid rights.
            /// </summary>
            public void SetPermissions()
            {
                var dt = _userPermissionDataSet;
                for (int i = 1; i<=Enum.GetNames(typeof(Module)).Length; i++)
                {
                    var actionDictionary = new Dictionary<int, int>();
                    for (int j = 1; j<=Enum.GetNames(typeof(ActionEnum)).Length; j++)
                    {
                        var value = (from a in dt where a.EntityID == i && a.ActionID == j select a.Answer).FirstOrDefault();
                        if (value != null)
                            actionDictionary.Add(j , (int) value);
                        else actionDictionary.Add(j, (int)Answer.No);
                    }
                    _permissions.Add(i, actionDictionary);
                }
            }
    
            /// <summary>
            /// Method to get the rights provided an entity (a module)
            /// and an action on that module.
            /// </summary>
            /// <param name="entityIdKey"></param>
            /// <param name="actionIdKey"></param>
            /// <returns></returns>
            public int GetPermission(int entityIdKey, int actionIdKey)
            {
                return _permissions[entityIdKey][actionIdKey]; 
            }   
        }
