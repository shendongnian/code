    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
              
                string xml =
                    "<ConfData>" +
                        "<CfgPerson>" +
                            "<DBID value=\"165\"/>" +
                            "<tenantDBID value=\"101\"/>" +
                            "<lastName value=\"GI\"/>" +
                            "<firstName value=\"Sim\"/>" +
                            "<employeeID value=\"simulator\"/>" +
                            "<userName value=\"SimGI\"/>" +
                            "<password value=\"[output suppressed]\"/>" +
                            "<isAgent value=\"1\"/>" +
                            "<isAdmin value=\"1\"/>" +
                            "<state value=\"1\"/>" +
                            "<isExternalAuth value=\"1\"/>" +
                            "<changePasswordOnNextLogin value=\"0\"/>" +
                            "<passwordHashAlgorithm value=\"0\"/>" +
                            "<PasswordUpdatingDate value=\"0\"/>" +
                        "</CfgPerson>" +
                        "<CfgPerson>" +
                            "<DBID value=\"257\"/>" +
                            "<tenantDBID value=\"101\"/>" +
                            "<lastName value=\"Scott\"/>" +
                            "<firstName value=\"Mike\"/>" +
                            "<employeeID value=\"00116019\"/>" +
                            "<userName value=\"scottmp\"/>" +
                            "<password value=\"[output suppressed]\"/>" +
                            "<appRanks>" +
                                "<CfgPersonRank>" +
                                "<appType value=\"70\"/>" +
                                "<appRank value=\"3\"/>" +
                                "</CfgPersonRank>" +
                                "<CfgPersonRank>" +
                                "<appType value=\"47\"/>" +
                                "<appRank value=\"3\"/>" +
                                "</CfgPersonRank>" +
                                "<CfgPersonRank>" +
                                "<appType value=\"49\"/>" +
                                "<appRank value=\"3\"/>" +
                                "</CfgPersonRank>" +
                            "</appRanks>" +
                            "<isAgent value=\"1\"/>" +
                            "<isAdmin value=\"1\"/>" +
                            "<state value=\"1\"/>" +
                            "<externalID value=\"Michael.Scott\"/>" +
                            "<isExternalAuth value=\"2\"/>" +
                            "<changePasswordOnNextLogin value=\"1\"/>" +
                            "<passwordHashAlgorithm value=\"0\"/>" +
                            "<PasswordUpdatingDate value=\"0\"/>" +
                        "</CfgPerson>" +
                    "</ConfData>";
                XDocument doc = XDocument.Parse(xml);
                DataTable dt = new DataTable();
                //build table
                foreach (XElement CfgPerson in doc.Descendants("CfgPerson"))
                {
                    List<XElement> appRanks = CfgPerson.Descendants("appRanks").ToList();
                    foreach (XElement column in CfgPerson.Elements())
                    {
                        string tagName = column.Name.LocalName;
                        if (tagName != "appRanks")
                        {
                            if (!dt.Columns.Contains(tagName))
                            {
                                dt.Columns.Add(tagName, typeof(string));
                            }
                        }
                        else
                        {
                            foreach(XElement rank in appRanks.Descendants("CfgPersonRank").Elements())
                            {
                                string tagName2 = rank.Name.LocalName;
                                if (!dt.Columns.Contains(tagName2))
                                {
                                    dt.Columns.Add(tagName2, typeof(string));                            }
                                }
                            }
                        }
                    }
                //add data
                DataRow row = null;
                foreach (XElement CfgPerson in doc.Descendants("CfgPerson"))
                {
                    List<XElement> appRanks = CfgPerson.Descendants("appRanks").ToList();
                    if (appRanks.Count == 0)
                    {
                        row = dt.Rows.Add();
                        foreach (XElement column in CfgPerson.Elements())
                        {
                            row[column.Name.LocalName] = column.Attribute("value").Value;
                        }
                    }
                    else
                    {
                        foreach (XElement appRank in appRanks.Descendants("CfgPersonRank"))
                        {
                            row = dt.Rows.Add();
                            foreach (XElement rank in appRank.Elements())
                            {
                                row[rank.Name.LocalName] = rank.Attribute("value").Value;
                            }
                            foreach (XElement column in CfgPerson.Elements())
                            {
                                if (column.Name.LocalName != "appRanks")
                                {
                                    row[column.Name.LocalName] = column.Attribute("value").Value;
                                }
                            }
                        }
                    }
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
