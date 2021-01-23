          }
    class VIPLogin : Login {
        public bool Authenticate(bool isVIP, string un, string pw) {
           if (isVIP) {
             return base.Authenticate(un,pw);
           }
           else {
          //ToDo: VIP login using database or openid or etc
             return true;
            }
          }
          }
