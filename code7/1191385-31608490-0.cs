    if ( inputDate.Month > 3 && inputDate.Month < 10 ) {
        resultDate = new DateTime( inputDate.Year, 12, 31, 23, 59, 59 );
    }
    else if (inputDate.Month > 9 ) {
        resultDate = new DateTime( inputDate.Year + 1, 6, 30, 23, 59, 59 );
    } else {
        resultDate = new DateTime( inputDate.Year, 6, 30, 23, 59, 59 );
    }
