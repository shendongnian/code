    Have a class contructor
    public class pdfPage extends PdfPageEventHelper{
          private int parametro;
          public pdfPage(int parametro){
             this.parametro=parametro;
          }
    //.....
    writer.setPageEvent(new pdfPage(int parametro));
    
    //in the same class you can pageEvent
    public void onEndPage(PdfWriter writer,Document document){
             try {
                //can access parametro 
               Text text = new Text(parametro);
               document.add(text);
             } catch (Exception e) {
    
             }
         }
