	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	using System.Diagnostics;
	using System.IO;
	namespace TestForm
	{
		public partial class testForm : Form
		{
			//	a List which will contain our external data. Named as the underlying list
			private List<UserClass> m_underList;
			public testForm()
			{
				InitializeComponent();
				m_underList = new List<UserClass> (3);
			}
			private void testForm_Load(object sender, EventArgs e)
			{
				//	Bind the CheckedListBox with the List
				//	The DataSource property is hidden so cast the object back to ListBox
				((ListBox)m_checkedListBox).DataSource = m_underList;
				//	Tell which property/field to display in the CheckedListBox
				//	The DisplayMember property is hidden so cast the object back to ListBox
				((ListBox)m_checkedListBox).DisplayMember = "PropToDisplay";
				/*
				 * The CheckedListBox is now in "read-only" mode, that means you can't add/remove/edit
				 * items from the listbox itself or edit the check states. You can't access
				 * the underlying list through the listbox. Considers it as a unidirectionnal mirror
				 * of the underlying list. The internal check state is disabled too, however
				 * the ItemCheck event is still raised...
				 */
				//	Manually set the ItemCheck event to set user defined objects
				m_checkedListBox.ItemCheck += new ItemCheckEventHandler(this.ItemCheck);
			}
			private void ItemCheck(object sender, ItemCheckEventArgs evnt)
			{
				if (sender == m_checkedListBox)
				{
					if (!m_checkedListBox.Sorted)
					{
						//	Set internal object's flag to remember the checkbox state
						m_underList[evnt.Index].IsChecked = (evnt.NewValue != CheckState.Unchecked);
						//	Monitoring
						Debug.WriteLine(m_underList[evnt.Index].ShowVarState());
					}
					else
					{
						//	If sorted... DIY
					}
				}
			}
			private void m_toggle_Click(object sender, EventArgs e)
			{
				if (sender == m_toggle)
				{
					if (m_toggle.Text == "Fill")
					{
						//	Fill the checkedListBox with some data
						//	Populate the list with external data.
						m_underList.Add(new UserClass("See? It works!", 42));
						m_underList.Add(new UserClass("Another example", 0, true));
						m_underList.Add(new UserClass("...", -7));
						m_toggle.Text = "Clear";
					}
					else
					{
						//	Empty the checkedListBox
						m_underList.Clear();
						m_toggle.Text = "Fill";
					}
					//	Refresh view
                    //  Remember CheckedListBox inherit from ListBox
					refreshView(m_checkedListBox, m_underList);
				}
			}
			//	Magic piece of code which refresh the listbox view
			void refreshView(ListBox lb, object dataSource)
			{
				CurrencyManager cm = (CurrencyManager)lb.BindingContext[dataSource];
				cm.Refresh();
			}
		}
	}
