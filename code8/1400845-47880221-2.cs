    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    
    namespace Test02.Data.Migrations
    {
        public partial class Seeder01 : Migration
        {
   
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                string sql = string.Empty;
    
                sql = "SET IDENTITY_INSERT State ON;";
                sql += "Insert into State (Id, Name) values ";
                sql += "(2, 'NSW'),";
                sql += "(3, 'VIC'),";
                sql += "(4, 'QLD'),";
                sql += "(5, 'SA')";
                sql += ";";
                sql += "SET IDENTITY_INSERT State OFF;";
                migrationBuilder.Sql(sql);
    
            }
    
            protected override void Down(MigrationBuilder migrationBuilder)
            {
                string sql = string.Empty;
                sql = "delete State;";
                migrationBuilder.Sql(sql);
    
    
            }
        }
    }
