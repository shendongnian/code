    from B in ChatUser
    join C in ChatUserConversation on B.IdChatUser equals C.IdChatUser
    group new {B,C} by new {B.IdChatUser, B.Nama, B.Hp} into g
    let CreatedTime = g.OrderBy(x=>x.C.CreatedTime).Select(x=>x.C.CreatedTime).FirstOrDefault()
    orderby CreatedTime descending
    select new 
    {
        IdChatUser = g.Key.IdChatUser, 
        Nama = g.Key.Nama, 
        Hp = g.Key.Hp, 
        CreatedTime = CreatedTime
    }
