        class MyClass {
            public string Currency { get; set; }
            public decimal Total { get; set; }
        }
        void Main() {
            var list1 = new List<MyClass>(){
	                new MyClass{ Currency = "USD" , Total = 10},
		            new MyClass{ Currency = "EUR" , Total = 25},		
	            };
            var list2 = new List<MyClass>(){
	                new MyClass{ Currency = "USD" , Total = 10},
		            new MyClass{ Currency = "EUR" , Total = 25},		
		            new MyClass{ Currency = "INR" , Total = 55},		
	            };
            var list3 = list1.Concat(list2);
            var list4 = list3.GroupBy(x => x.Currency).Select(y => new MyClass {
                Currency = y.Key,
                Total = y.Sum(z => z.Total)
            });
            Console.WriteLine(list4);
        }
