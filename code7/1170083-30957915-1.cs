    //using MyEntities; (don't need this)
    namespace MyEntities
    {
        public partial class ReturnedItem
        {
           public string fullDetails() {
             return "Tracking Number:" + trackingNumber;
           }
        }
    }
