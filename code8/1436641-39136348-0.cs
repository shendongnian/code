    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace myNamespace
	{
		public partial class expresion2 : System.Web.UI.Page
		{
			public String nombre, email, telefono, contra, usuario;
			protected void Page_Load(object sender, EventArgs e)
			{
				nombre = txtNombre.Text;
				email = txtEmail.Text;
				telefono = txtTel.Text;
				contra = txtContra.Text;
				usuario = txtUser.Text;
			}
		}
	}
