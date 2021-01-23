    public class WhiteListElement
       {
          private const byte EQL = 0;  
          private const byte CTN = 1;  
          private const byte COMMON_NAME = 0;  
          private const byte ORG = 1;  
          private const byte ORG_UNIT = 2;  
          private const byte LOC = 3;  
          private const byte STATE = 4; 
          private const byte COUNTRY = 5;   
    
          private string[,] Subject;  
          private string[,] Issuer;   
    
          private string MinTlsLevel; 
          private string Customer;
    
    
          public WhiteListElement()
          {
             Subject = new string[6, 2];
             Issuer = new string[6, 2];
             Customer = "";
             MinTlsLevel = "";
          }
    
          //---- set/get functions ---- example
          public string GetCommonName(bool SubjectVal, bool Name)
          {  
             if (true == SubjectVal) { if (true == Name) return Subject[COMMON_NAME, 0]; else return Subject[COMMON_NAME, 1]; }
             else { if (true == Name) return Issuer[COMMON_NAME, 0]; else return Issuer[COMMON_NAME, 1]; }
          }
          public void SetCommonName(bool SubjectVal, bool Name, string NewValue)
          {  
             if (true == SubjectVal) { if (true == Name) Subject[COMMON_NAME, 0] = NewValue; else Subject[COMMON_NAME, 1] = NewValue; }
             else { if (true == Name) Issuer[COMMON_NAME, 0] = NewValue; else Issuer[COMMON_NAME, 1] = NewValue; }
          }
    
       }
