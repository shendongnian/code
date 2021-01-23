    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
      public class SingleValueEventArgs : EventArgs
      {
        public int Value { get; set; }
      }
    
      public class MultiValueEventArgs : EventArgs
      {
        private List<int> _values = new List<int>(); // Private to prevent handlers from messing with each others' values
    
        public IEnumerable<int> Values
        {
          get { return _values; }
        }
    
        public void AddValue(int value) { _values.Add(value); }
      }
    
      public class Exposer
      {
        public event EventHandler<SingleValueEventArgs> WantSingleValue;
        public event EventHandler<MultiValueEventArgs> WantMultipleValues;
    
        public void Run()
        {
          if (WantSingleValue != null)
          {
            var args = new SingleValueEventArgs();
            WantSingleValue(this, args);
            Console.WriteLine("Last handler produced " + args.Value.ToString());
          }
    
          if (WantMultipleValues != null)
          {
            var args = new MultiValueEventArgs();
            WantMultipleValues(this, args);
            foreach (var value in args.Values)
            {
              Console.WriteLine("A handler produced " + value.ToString());
            }
          }
        }
      }
    
      public class Handler
      {
        private int _value;
    
        public Handler(Exposer exposer, int value)
        {
          _value = value;
          exposer.WantSingleValue += exposer_WantSingleValue;
          exposer.WantMultipleValues += exposer_WantMultipleValues;
        }
    
        void exposer_WantSingleValue(object sender, SingleValueEventArgs e)
        {
          Console.WriteLine("Handler assigning " + _value.ToString());
          e.Value = _value;
        }
    
        void exposer_WantMultipleValues(object sender, MultiValueEventArgs e)
        {
          Console.WriteLine("Handler adding " + _value.ToString());
          e.AddValue(_value);
        }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
          var exposer = new Exposer();
    
          for (var i = 0; i < 5; i++)
          {
            new Handler(exposer, i);
          }
    
          exposer.Run();
        }
      }
    }
