    public interface IOrder {
        void perform(Query query)
    }
    public abstract class AbstractOrder : IOrder {
        private string orderString;
        public AbstractOrder(string orderString) {
             this.orderString = orderString;
        }
    }
    public class OrderAsc {
        public OrderAsc(string orderString) : base(orderString) {
        }
    
        public Query perform(Query query) {
            query = query.OrderBy(s => s.Course_Count); //here you still have to do a mapping between orderString and your db field s.Course_count 
            return query;
        }
    }
    public class OrderDesc {
        public OrderDesc(string orderString) : base(orderString) {
        }
    
        public Query perform(Query query) {
            query = query.OrderByDescending(s => s.Course_Count); //here you still have to do a mapping between orderString and your db field s.Course_count, or maybe it's equal, then you can just replace it.
            return query;
        }
    }
