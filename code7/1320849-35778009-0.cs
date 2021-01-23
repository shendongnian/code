    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    using System.Configuration;
    using MySql.Data.MySqlClient;
    using System.IO;
    public MySqlConnection myInit()
    {
        return new MySqlConnection(
            "host=" + ConfigurationManager.AppSettings["mysqlHost"] +
            ";user=" + ConfigurationManager.AppSettings["mysqlUser"] +
            ";password=" + ConfigurationManager.AppSettings["mysqlPass"] +
            ";database=" + ConfigurationManager.AppSettings["mysqlDb"]);
    }
    public Dictionary<string,byte[]> getPDF(int pdfid)
    {
        string query = "SELECT md5_string, data FROM pdf,pdf_view WHERE pdf.id=" + pdfid + " and pdf_view.id=pdf.id";
        MySqlConnection con = myInit();
        MySqlCommand cmd = new MySqlCommand(query, con);
        MemoryStream ms;
        BinaryWriter bw;                        // Streams the BLOB to the FileStream object.
        Dictionary<string, byte[]> result = new Dictionary<string, byte[]>();
        int bufferSize = 1000;                   // Size of the BLOB buffer.
        byte[] outbyte = new byte[bufferSize];  // The BLOB byte[] buffer to be filled by GetBytes.
        long retval;                            // The bytes returned from GetBytes.
        long startIndex = 0;
        con.Open();
        MySqlDataReader myReader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
        while (myReader.Read())
        {
            ms = new MemoryStream();
            bw = new BinaryWriter(ms);
            string md5 = myReader.GetString(0);
            // Reset the starting byte for the new BLOB.
            startIndex = 0;
            // Read the bytes into outbyte[] and retain the number of bytes returned.
            retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
            // Continue reading and writing while there are bytes beyond the size of the buffer.
            while (retval == bufferSize)
            {
                bw.Write(outbyte);
                bw.Flush();
                // Reposition the start index to the end of the last buffer and fill the buffer.
                startIndex += bufferSize;
                retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
            }
            // Write the remaining buffer.
            bw.Write(outbyte, 0, (int)retval - 1);
            bw.Flush();
            result.Add(md5, ms.ToArray());
            // Close the output file.
            bw.Close();
            ms.Close();
        }
        // Close the reader and the connection.
        myReader.Close();
        con.Close();
        return result;
    }
