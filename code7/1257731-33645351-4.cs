    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
     
    namespace Learn.MVVM.Example.Views
    {
        public interface IView
        {
            void ShowView();
            void ShowViewAsModal();
            void SetDataContext(object dataContext);
        }
    }
