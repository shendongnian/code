    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    public partial class BaseForm : Form
    {
        [TypeConverter(typeof(MyCultureInfoConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CultureInfo FormLanguage
        {
            get
            {
                return TypeDescriptor.GetProperties(this)["Language"]
                    .GetValue(this) as CultureInfo;
            }
            set
            {
                TypeDescriptor.GetProperties(this)["Language"].SetValue(this, value);
            }
        }
    }
    public class MyCultureInfoConverter : CultureInfoConverter
    {
        public override StandardValuesCollection 
            GetStandardValues(ITypeDescriptorContext context)
        {
            var values = CultureInfo.GetCultures(CultureTypes.SpecificCultures | 
                CultureTypes.NeutralCultures)
                .Where(x => x.Name == "fa-IR" || x.Name == "en-US").ToList();
            values.Insert(0, CultureInfo.InvariantCulture);
            return new StandardValuesCollection(values);
        }
    }
