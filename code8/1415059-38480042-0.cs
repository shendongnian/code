    public class StringValue {
          public StringValue(string s) {
            this._value = s;
          }
          public string Text {
            get {
              return this._value;
            }
            set {
              this._value = value;
            }
          }
    
          private string _value;
        }
