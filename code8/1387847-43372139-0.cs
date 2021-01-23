    using CommonBusinessModel.Metadata;
    using GHCOMvc.Controllers;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    
    namespace AtlasMvcWebsite.Binders
    {
      public class FieldModelBinder : DefaultModelBinder
      {
        // this runs before any filters (except auth filters)
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
          var form = controllerContext.HttpContext.Request.Form;
          Type type = typeof(GHCOBusinessModel.GHCOPPAType);
          AtlasKernelBusinessModel.VersionedObject instance = PolicyController.Policy;
    
          foreach ((var value, var member) in (from string input in form
                                               let fi = type.GetField(input)
                                               where fi != null
                                               let mi = new MemberInformation(fi, instance)
                                               where !mi.ReadOnly
                                               select (form[input], mi)))
            member.SetValue(value);
    
          return instance;
        }
    
      }
    }
