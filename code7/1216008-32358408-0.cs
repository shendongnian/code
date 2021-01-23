    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                        "<clientes>" +
                            "<cliente>" +
                                "<nome>Cliente1</nome>" +
                                "<contatos>" +
                                    "<contato>" +
                                        "<nome>Contato1</nome>" +
                                    "</contato>" +
                                    "<contato>" +
                                        "<nome>Contato2</nome>" +
                                    "</contato>" +
                                "</contatos>" +
                            "</cliente>" +
                            "<cliente>" +
                                "<nome>Cliente2</nome>" +
                                "<contatos>" +
                                    "<contato>" +
                                        "<nome>Contato3</nome>" +
                                    "</contato>" +
                                    "<contato>" +
                                        "<nome>Contato4</nome>" +
                                    "</contato>" +
                                "</contatos>" +
                            "</cliente>" +
                        "</clientes>";
                XDocument doc = XDocument.Parse(input);
                DataSet ds = new DataSet();
       
                //ds.ReadXml("c:\xmlfile.xml");
                ds.Tables.Add("CLIENTES");
                DataTable dtClientes = ds.Tables["CLIENTES"];
                dtClientes.Columns.Add("CLIENTES", typeof(string));
                ds.Tables.Add("CONTATOS");
                DataTable dtContatos = ds.Tables["CONTATOS"];
                dtContatos.Columns.Add("CLIENTES", typeof(string));
                dtContatos.Columns.Add("CONTATOS", typeof(string));
                var clientes = doc.Descendants("cliente").Select(x => new {
                    nome = x.Element("nome").Value,
                    contatos = x.Descendants("contato").Select(y => y.Element("nome").Value).ToList()
                }).ToList();
                foreach (var cliente in clientes)
                {
                    dtClientes.Rows.Add(new object[] { cliente.nome });
                    foreach (var contato in cliente.contatos)
                    {
                        dtContatos.Rows.Add(new object[] { cliente.nome, contato });
                    }
                }
            }
        }
    }
    ​
