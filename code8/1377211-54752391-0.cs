    public interface IVisualPresentor
    { void Display(params object[] parms) };
    public class FormAlpha.VPS : IVisualPresentor
    {  
         public void Display(params object[] parms)
         {
           //validate parms if needed and cast to type specific data
           //for example it needs session data parms[1] and customer parms[2]
           var form = new FormAlpha();
           var model = new FormAlphaViewModel( sessionData, customer );
           form.DataBinding = model;
           if ((bool)parms[0])
              form.Show(); 
           else 
              form.ShowDialog();
        }
     }
