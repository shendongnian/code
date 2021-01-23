    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class Form2
    {
    
    	private void Form2_Load(System.Object sender, System.EventArgs e)
    	{
    		TextBox1.Text = "Enter your security Password";
    	}
    
    	public void change(TextBox txt_pwd)
    	{
    		txt_pwd.Text = "";
    		txt_pwd.PasswordChar = "*";
    	}
    
    	private void TextBox1_Click(object sender, System.EventArgs e)
    	{
    		change(TextBox1);
    	}
    
    	private void TextBox1_GotFocus(object sender, System.EventArgs e)
    	{
    		change(TextBox1);
    	}
    	public Form2()
    	{
    		Load += Form2_Load;
    	}
    }
