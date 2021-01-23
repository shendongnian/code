    \/.*?\[usp_Remove\].*?$\s+GO
    Options: Case sensitive; Exact spacing; Dot matches line breaks; ^$ match at line breaks; Numbered capture
    
    Match the character “/” literally «\/»
    Match any single character «.*?»
       Between zero and unlimited times, as few times as possible, expanding as needed (lazy) «*?»
    Match the character “[” literally «\[»
    Match the character string “usp_Remove” literally (case sensitive) «usp_Remove»
    Match the character “]” literally «\]»
    Match any single character «.*?»
       Between zero and unlimited times, as few times as possible, expanding as needed (lazy) «*?»
    Assert position at the end of a line (at the end of the string or before a line break character) (line feed) «$»
    Match a single character that is a “whitespace character” (any Unicode separator, tab, line feed, carriage return, vertical tab, form feed, next line) «\s+»
       Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
    Match the character string “GO” literally (case sensitive) «GO»
