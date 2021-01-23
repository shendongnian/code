    Spartacus.Database.Generic v_database;
    Spartacus.Reporting.Report v_report;
    System.Data.DataTable v_table;
    v_database = new Spartacus.Database.Postgresql("127.0.0.1", "database", "postgres", "password");
    v_table = v_database.Query(
        "select 'Example of Report made with Spartacus' as title, " +
        "       product, " +
        "       description, " +
        "       unit, " +
        "       quantity, " +
        "       total_cost, " +
        "       unit_cost " +
        "from table", "REPORT");
    v_report = new Spartacus.Reporting.Report(1, "template.xml", v_table);
    v_report.Execute();
    v_report.Save("report.pdf");
