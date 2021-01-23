    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    namespace Samples
    {
        public sealed class NoBrowsableAttribute : TypeDescriptionProvider
        {
            public static bool Enabled
            {
                get { return instance.enabled; }
                set { instance.enabled = value; }
            }
            private static readonly NoBrowsableAttribute instance = new NoBrowsableAttribute();
            private bool enabled;
            private NoBrowsableAttribute() : base(TypeDescriptor.GetProvider(typeof(BrowsableAttribute)))
            {
                TypeDescriptor.AddProvider(this, typeof(BrowsableAttribute));
            }
            public override Type GetReflectionType(Type objectType, object instance)
            {
                if (enabled && objectType == typeof(BrowsableAttribute)) return typeof(NoBrowsableAttribute);
                return base.GetReflectionType(objectType, instance);
            }
            public static readonly BrowsableAttribute Default = BrowsableAttribute.No;
        }
        static class Test
        {
            class Person
            {
                public int Id { get; set; }
                [Browsable(true)]
                public string Name { get; set; }
                [Browsable(true)]
                public string Description { get; set; }
                public int Age { get; set; }
            }
            [STAThread]
            static void Main()
            {
                NoBrowsableAttribute.Enabled = true;
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var data = Enumerable.Range(1, 10).Select(i => new Person { Id = i, Name = "Name" + i, Description = "Description" + i }).ToList();
                var form = new Form { StartPosition = FormStartPosition.CenterScreen, ClientSize = new Size(500, 300) };
                var split = new SplitContainer { Dock = DockStyle.Fill, Parent = form, FixedPanel = FixedPanel.Panel2, SplitterDistance = 300 };
                var dg = new DataGridView { Dock = DockStyle.Fill, Parent = split.Panel1 };
                var pg = new PropertyGrid { Dock = DockStyle.Fill, Parent = split.Panel2, ToolbarVisible = false, PropertySort = PropertySort.NoSort };
                dg.BindingContextChanged += (sender, e) => {
                    var bm = dg.BindingContext[data];
                    pg.SelectedObject = bm.Current;
                    bm.CurrentChanged += (_sender, _e) => pg.SelectedObject = bm.Current;
                };
                dg.DataSource = data;
                Application.Run(form);
            }
        }
    }
