    public class GroupClass
    {
        private static LinkedList<GroupClass> tmp = new LinkedList<GroupClass>();
        /* some code */
        public static LinkedList<GroupClass> GetGroupList()
        {
            var tmp1 = tmp;
            VKRequest.Dispatch<VKList<VKGroup>> ( new VKRequestParameters ( "groups.get", "extended", "1", "filter", "admin, editor, moder", "fields", "photo_100" ), ( res ) =>
            {
                if ( res.ResultCode == VKResultCode.Succeeded && res.Data.count > 0 )
                {
                    var item = res.Data.items[0];
                    tmp1.AddLast( new GroupClass ( item.id, item.name, item.screen_name, item.photo_100 ) );                            
                }
            }); //here
            return tmp1;
        }
    }
