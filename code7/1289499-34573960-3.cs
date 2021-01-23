          }
    class VIPLogin : Login {
        public bool Authenticate(bool isVIP, string un, string pw) {
           // if it's not a VIP (like checkbox control ticked) use the generic parent class
           if (!isVIP) {
             return base.Authenticate(un,pw);
           }
           else {
          //ToDo: VIP login using database or openid or etc
             return true;
            }
          }
          }
