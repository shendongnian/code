    namespace {your namespace}
    {
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Data.Items;
    using Sitecore.Form.Core.Controls.Data;
    /// <summary>
    /// The drop list field.
    /// </summary>
    public class DropListField : Sitecore.Forms.Mvc.Models.Fields.DropListField
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DropListField"/> class.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public DropListField(Item item)
            : base(item)
        {
        }
        /// <summary>
        /// The get result.
        /// </summary>
        /// <returns>
        /// The <see cref="ControlResult"/>.
        /// </returns>
        public override ControlResult GetResult()
        {
            var value = this.Value as List<string>;
            var selectListItem = this.Items.SingleOrDefault(x => x.Value == value.First());
            var str = selectListItem != null ? selectListItem.Text : string.Empty;
            return new ControlResult(this.ID.ToString(), this.Title, selectListItem != null ? selectListItem.Value : string.Empty, str);
        }
    }
    }
