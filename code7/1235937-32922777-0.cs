        public class MyObs : ObservableCollection<MyClass> {
          public void Fun() {
              var n = new MyClass();
              int startIndex = 0; // parameter
              int length = 2;  // parameter
              for (int i = 0; i < length; i++) {
                  n.Text += this [startIndex].Text;
                  this.RemoveAt(startIndex);
              }
              this.Insert(0,n); // PAY ATTENTION THAT I INSERT AT 0 !
          }
        }
        public class MyClass {
          public string Text { get; set; }
          public override string ToString() {
              return Text;
          }
        }
