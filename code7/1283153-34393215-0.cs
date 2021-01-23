    public class Test{
    static void Main(string[] args) {
    
          try{ 
    XPathReader xpr  = new XPathReader("books.xml", "//book/title"); 
    
                while (xpr.ReadUntilMatch()) {
                   Console.WriteLine(xpr.ReadString()); 
                 }      
                Console.ReadLine(); 
       }catch(XPathReaderException xpre){
          Console.WriteLine("XPath Error: " + xpre);
          }catch(XmlException xe){
             Console.WriteLine("XML Parsing Error: " + xe);
          }catch(IOException ioe){
             Console.WriteLine("File I/O Error: " + ioe);
          }
       }  
    }
