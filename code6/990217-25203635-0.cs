    public class EditPaymentMethodModel
    {
      ....
      [ViagogoCpfCnpj(CardNoProperty = "CardNumber")]
      public string CpfOrCnpj
      {
        get
        {
          if (PaymentViewData != null && PaymentViewData is CreditCardViewData)
          {
            return ((CreditCardViewData)PaymentViewData).CpfOrCnpj;
          }
          return null;
        }
      }
    }
