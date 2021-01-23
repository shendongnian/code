    SELECT IDEvent
    , events.IDSubject
    ,events.month
    ,events.year
    FROM events
    LEFT OUTER JOIN subjects ON events.IDSubject = subjects.IDSubject
    INNER JOIN classes ON subjects.IDClass = classes.IDClass
    INNER JOIN students ON classes.IDClass = students.IDClass
    WHERE (events.IDSubject = 0 OR subjects.IDSubject is not null)
    AND events.month = 10
    AND events.year = 2015
    AND (students.DNI = DNI OR events.IDSubject = 0)
