    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Duplicates
    {
    
        public static class EnumerableExtensions
        {
            public static bool HasDuplicates<T, I>(this IEnumerable<T> enumerable, Func<T, I> identityGetter, IEqualityComparer<I> comparer )
            {
                var hashSet = new HashSet<I>(comparer);
                foreach (var item in enumerable)
                {
                    var identity = identityGetter(item);
                    if (hashSet.Contains(identity)) return true;
                    hashSet.Add(identity);
                }
                return false;
            }
    
            public static bool HasDuplicates<T, I>(this IEnumerable<T> enumerable, Func<T, I> identityGetter)
            {
                return enumerable.HasDuplicates(identityGetter, EqualityComparer<I>.Default);
            }
        }
    
        public class Booking
        {
            public int BookingId { get; set; }
            public string BookingName { get; set; }
        }
    
        public class Customer
        {
            public string CustomerId { get; set; }
            public string Name { get; set; }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                var bookings = new List<Booking>()
                {
                    new Booking { BookingId = 1, BookingName = "Booking 1" },
                    new Booking { BookingId = 1, BookingName = "Booking 1" }
                };
    
                Console.WriteLine("Q: There are duplicate bookings?. A: {0}", bookings.HasDuplicates(x => x.BookingId));
    
                var customers = new List<Customer>()
                {
                    new Customer { CustomerId = "ALFKI", Name = "Alfred Kiss" },
                    new Customer { CustomerId = "ANATR", Name = "Ana Trorroja" }
                };
    
                Console.WriteLine("Q: There are duplicate customers?. A: {0} ", customers.HasDuplicates(x => x.CustomerId));
    
            }
        }
    }
