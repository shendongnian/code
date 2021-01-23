    SELECT b.ISBN, b.SSID
    FROM
        Books b
        JOIN Sold s on b.ISBN = s.ISBN 
        JOIN Copy c on b.ISBN = c.ISBN
        LEFT JOIN Sold s2 on b.ISBN = s2.ISBN and b.SSID = s2.SSID
        LEFT JOIN Copy c2 on b.ISBN = c2.ISBN and b.SSID = c2.SSID
    WHERE s2.ISBN is null or c2.ISBN is null
