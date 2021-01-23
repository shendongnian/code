    ISecurisable shoppingCart = new shoppingCart();
    shoppingCart.Deactivate();
    public interface ISecurisable
    {
        void Deactivate();
    }
    public partial class shoppingCart : ISecurisable
    {
         public void Deactivate()
         {
             shoppingCartid = null;
             IsActive = false;
             foreach (var shoppingCartDetails in Childs)
             {
                shoppingCartDetails.ParentId = ParentId;
             }
         }
    }
