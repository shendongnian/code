    foreach (string c in row)
    {
        string[] rejects = c.Split('\t');
        if (rejects.Length > 30)
        {
            string Column1 = rejects[0];
            string Column2 = rejects[1];
            string Column3 = rejects[2];
            string Column4 = rejects[3];
            string Column5 = rejects[4];
            string Column6 = rejects[5];
            string Column7 = rejects[6];
            string Column8 = rejects[7];
            string Column9 = rejects[8];
            string Column10 = rejects[9];
            string Column11 = rejects[10];
            string Column12 = rejects[11];
            string Column13 = rejects[12];
            string Column14 = rejects[13];
            string Column15 = rejects[14];
            string Column16 = rejects[15];
            string Column17 = rejects[16];
            string Column18 = rejects[17];
            string Column19 = rejects[18];
            string Column20 = rejects[19];
            string Column21 = rejects[20];
            string Column22 = rejects[21];
            string Column23 = rejects[22];
            string Column24 = rejects[23];
            string Column25 = rejects[24];
            string Column26 = rejects[25];
            string Column27 = rejects[26];
            string Column28 = rejects[27];
            string Column29 = rejects[28];
            string Column30 = rejects[29];
            string Column31 = rejects[30];
            string Insert = "INSERT INTO tblReject_test (sop_instance_uid, study_instance_uid, accession_number, patient_id, patient_name, date_of_birth, sex, study_date, study_time, mpm_code, body_part_examined, ank_menu_name, kanji_menu_name, s_value, l_value, ip_number, fcr_image_id, technologist, requesting_department, Kanji_requesting_department, size_code, film_mark1, film_mark2, status, technologist_code, ip_number2, reject_category, reject_comment, code, reject_image, department_id) VALUES ('" + Column1 + "," + Column2 + "," + Column3 + "," + Column4 + "," + Column5 + "," + Column6 + "," + Column7 + "," + Column8 + "," + Column9 + "," + Column10 + "," + Column11 + "," + Column12 + "," + Column13 + "," + Column14 + "," + Column15 + "," + Column16 + "," + Column17 + "," + Column18 + "," + Column19 + "," + Column20 + "," + Column21 + "," + Column22 + "," + Column23 + "," + Column24 + "," + Column25 + "," + Column26 + "," + Column27 + "," + Column28 + "," + Column29 + "," + Column30 + "," + Column31 + "')";
        }
    }
