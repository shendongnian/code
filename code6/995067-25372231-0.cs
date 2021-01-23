    public static class TimeHelper{
    public static string TimeSpanString(this DateTime date) {
                var Now = DateTime.Now-date; //better to use DateTime.UtcNow
                if(Now.Days>0){
                    return Now.Days+" Days "+Now.Hours+" Hours "+Now.Minutes+" Minutes";
                }
                if (Now.Hours > 0)
                {
                    return Now.Hours + " Hours " + Now.Minutes + " Minutes";
                }
                return  Now.Minutes + " Minutes";
            
            }
       }
